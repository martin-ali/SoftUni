package issuetracker.entity;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "issues")
public class Issue
{
    private Integer id;

    private String title;

    private String content;

    private Integer priority;

    public Issue()
    {
    }

    public Issue(String title, String content, Integer priority)
    {
        this.title = title;
        this.content = content;
        this.priority = priority;
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
    @Column(columnDefinition = "text", nullable = false)
    public String getTitle()
    {
        return title;
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    @NotNull
    @Column(columnDefinition = "text", nullable = false)
    public String getContent()
    {
        return content;
    }

    public void setContent(String content)
    {
        this.content = content;
    }

    @NotNull
    @Column(nullable = false)
    public Integer getPriority()
    {
        return priority;
    }

    public void setPriority(Integer priority)
    {
        this.priority = priority;
    }
}
