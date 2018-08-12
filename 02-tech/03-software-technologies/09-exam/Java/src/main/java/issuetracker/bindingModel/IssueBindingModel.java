package issuetracker.bindingModel;

import javax.validation.constraints.NotNull;

public class IssueBindingModel
{
    private String title;

    private String content;

    private Integer priority;

    @NotNull
    public String getTitle()
    {
        return title;
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    @NotNull
    public String getContent()
    {
        return content;
    }

    public void setContent(String content)
    {
        this.content = content;
    }

    @NotNull
    public Integer getPriority()
    {
        return priority;
    }

    public void setPriority(Integer priority)
    {
        this.priority = priority;
    }
}
