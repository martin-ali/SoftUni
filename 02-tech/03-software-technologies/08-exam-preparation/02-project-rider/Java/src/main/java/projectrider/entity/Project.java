package projectrider.entity;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "projects")
public class Project
{
    private Integer id;

    private String title;

    private String description;

    private Double budget;

    public Project()
    {
    }

    public Project(String title, String description, Double budget)
    {
        this.title = title;
        this.description = description;
        this.budget = budget;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId()
    {
        return id;
    }

    public void setId(Integer id)
    {
        this.id = id;
    }

    @NotNull
    @Column(nullable = false)
    public String getTitle()
    {
        return title;
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    @NotNull
    @Column(nullable = false)
    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    @NotNull
    @Column(nullable = false)
    public Double getBudget()
    {
        return budget;
    }

    public void setBudget(Double budget)
    {
        this.budget = budget;
    }
}
