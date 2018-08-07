package javaBlog.controller;

import javaBlog.bindingModel.CommentBindingModel;
import javaBlog.entity.Article;
import javaBlog.entity.Comment;
import javaBlog.entity.User;
import javaBlog.repository.ArticleRepository;
import javaBlog.repository.CommentRepository;
import javaBlog.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/comment")
public class CommentController
{
    @Autowired
    private CommentRepository commentRepository;

    @Autowired
    private ArticleRepository articleRepository;

    @Autowired
    private UserRepository userRepository;

    private User getCurrentUser()
    {
        if (SecurityContextHolder.getContext().getAuthentication().getCredentials() != null)
        {
            return null;
        }

        UserDetails userDetails = (UserDetails) SecurityContextHolder
                .getContext()
                .getAuthentication()
                .getPrincipal();

        User user = this.userRepository.findByEmail(userDetails.getUsername());

        return user;
    }

    private Boolean commentUserIsAuthor(Integer commentId)
    {
        Integer commentAuthorId = this.commentRepository.findOne(commentId).getAuthor().getId();
        User user = this.getCurrentUser();

        return user != null && (commentAuthorId.equals(user.getId()));
    }

    @GetMapping("/details/{id}")
    public String details(Model model, @PathVariable Integer id)
    {
        if (!this.commentRepository.exists(id))
        {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);

        model.addAttribute("userIsAuthor", this.commentUserIsAuthor(id));
        model.addAttribute("comment", comment);
        model.addAttribute("view", "comment/details");

        return "base-layout";
    }

    @GetMapping("/create/{articleId}")
    @PreAuthorize("isAuthenticated()")
    public String create(Model model, @PathVariable Integer articleId)
    {
        model.addAttribute("articleId", articleId);
        model.addAttribute("view", "comment/create");

        return "base-layout";
    }

    @PostMapping("/create/{articleId}")
    @PreAuthorize("isAuthenticated()")
    public String createProcess(CommentBindingModel commentModel, @PathVariable Integer articleId)
    {
        User user = getCurrentUser();
        Article article = this.articleRepository.findOne(articleId);

        Comment comment = new Comment(commentModel.getContent(), user, article);
        this.commentRepository.saveAndFlush(comment);

        return "redirect:/article/details/" + articleId;
    }

    @GetMapping("/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String edit(Model model, @PathVariable Integer id)
    {
        if (!this.commentRepository.exists(id) || !this.commentUserIsAuthor(id))
        {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);

        model.addAttribute("comment", comment);
        model.addAttribute("view", "comment/edit");

        return "base-layout";
    }

    @PostMapping("/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String editProcess(CommentBindingModel commentModel, @PathVariable Integer id)
    {
        if (!this.commentRepository.exists(id) || !this.commentUserIsAuthor(id))
        {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);
        comment.setContent(commentModel.getContent());

        this.commentRepository.saveAndFlush(comment);

        return "redirect:/comment/details/" + id;
    }

    @GetMapping("/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String delete(Model model, @PathVariable Integer id)
    {
        if (!this.commentRepository.exists(id) || !this.commentUserIsAuthor(id))
        {
            return "redirect:/";
        }

        Comment comment = this.commentRepository.findOne(id);

        model.addAttribute("comment", comment);
        model.addAttribute("view", "comment/delete");

        return "base-layout";
    }

    @PostMapping("/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String deleteProcess(@PathVariable Integer id)
    {
        if (!this.commentRepository.exists(id) || !this.commentUserIsAuthor(id))
        {
            return "redirect:/";
        }

        int articleId = this.commentRepository.getOne(id).getArticle().getId();
        this.commentRepository.delete(id);

        return "redirect:/article/details/" + articleId;
    }
}
