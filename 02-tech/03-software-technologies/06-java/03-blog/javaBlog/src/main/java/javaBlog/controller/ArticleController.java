package javaBlog.controller;

import javaBlog.bindingModel.ArticleBindingModel;
import javaBlog.entity.Article;
import javaBlog.entity.User;
import javaBlog.repository.ArticleRepository;
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
@RequestMapping("/article")
public class ArticleController
{
    @Autowired
    private ArticleRepository articleRepository;

    @Autowired
    private UserRepository userRepository;

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
        UserDetails userDetails = (UserDetails) SecurityContextHolder
                .getContext()
                .getAuthentication()
                .getPrincipal();
        User user = this.userRepository.findByEmail(userDetails.getUsername());

        Article article = new Article(articleModel.getTitle(), articleModel.getContent(), user);
        this.articleRepository.saveAndFlush(article);

        return "redirect:/";
    }

    @GetMapping("/details/{id}")
    public String details(Model model, @PathVariable Integer id)
    {
        if (!this.articleRepository.exists(id))
        {
            return "redirect:/";
        }

        Article article = this.articleRepository.findOne(id);

        model.addAttribute("article", article);
        model.addAttribute("view", "article/details");

        return "base-layout";
    }

    @GetMapping("/edit/{id}")
    @PreAuthorize("isAuthenticated()")
    public String edit(Model model, @PathVariable Integer id)
    {
        if (!this.articleRepository.exists(id))
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
        if (!this.articleRepository.exists(id))
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
        if (!this.articleRepository.exists(id))
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
        if (!this.articleRepository.exists(id))
        {
            return "redirect:/";
        }

        this.articleRepository.delete(id);

        return "redirect:/";
    }
}
