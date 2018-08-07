package javaBlog.controller;

import javaBlog.bindingModel.ArticleBindingModel;
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

import java.util.Comparator;
import java.util.stream.Stream;

@Controller
@RequestMapping("/article")
public class ArticleController
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

    private Boolean articleUserIsAuthor(Integer articleId)
    {
        Integer articleAuthorId = this.articleRepository.findOne(articleId).getAuthor().getId();
        User user = this.getCurrentUser();

        return user != null && (articleAuthorId.equals(user.getId()));
    }

    @GetMapping("/details/{id}")
    public String details(Model model, @PathVariable Integer id)
    {
        if (!this.articleRepository.exists(id))
        {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);
        Stream<Comment> comments = article
                .getComments()
                .stream()
                .sorted(Comparator.comparing(Comment::getId));

        model.addAttribute("userIsAuthor", this.articleUserIsAuthor(id));
        model.addAttribute("comments", comments);
        model.addAttribute("article", article);
        model.addAttribute("view", "article/details");

        return "base-layout";
    }

    @GetMapping("/create")
    @PreAuthorize("isAuthenticated()")
    public String create(Model model)
    {
        model.addAttribute("view", "article/create");
        return "base-layout";
    }

    @PostMapping("/create")
    @PreAuthorize("isAuthenticated()")
    public String createProcess(ArticleBindingModel articleModel)
    {
        User user = this.getCurrentUser();

        Article article = new Article(articleModel.getTitle(), articleModel.getContent(), user);
        this.articleRepository.saveAndFlush(article);

        return "redirect:/";
    }

    @GetMapping("/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String edit(Model model, @PathVariable Integer id)
    {
        if (!this.articleRepository.exists(id) || !this.articleUserIsAuthor(id))
        {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);

        model.addAttribute("article", article);
        model.addAttribute("view", "article/edit");

        return "base-layout";
    }

    @PostMapping("/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String editProcess(ArticleBindingModel articleModel, @PathVariable Integer id)
    {
        if (!this.articleRepository.exists(id) || !this.articleUserIsAuthor(id))
        {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);
        article.setContent(articleModel.getContent());
        article.setTitle(articleModel.getTitle());

        this.articleRepository.saveAndFlush(article);

        return "redirect:/article/details/" + id;
    }

    @GetMapping("/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String delete(Model model, @PathVariable Integer id)
    {
        if (!this.articleRepository.exists(id) || !articleUserIsAuthor(id))
        {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);

        model.addAttribute("article", article);
        model.addAttribute("view", "article/delete");

        return "base-layout";
    }

    @PostMapping("/delete/{id}")
    @PreAuthorize("isAuthenticated()")
    public String deleteProcess(@PathVariable Integer id)
    {
        if (this.articleRepository.exists(id) && this.articleUserIsAuthor(id))
        {
            this.articleRepository.delete(id);
        }


        return "redirect:/";
    }
}
