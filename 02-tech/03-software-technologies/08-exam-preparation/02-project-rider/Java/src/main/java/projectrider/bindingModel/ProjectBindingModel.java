package projectrider.bindingModel;

import javax.validation.constraints.NotNull;

public class ProjectBindingModel
{
    private String title;

    private String description;

    private Double budget;

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
    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    @NotNull
    public Double getBudget()
    {
        return budget;
    }

    public void setBudget(Double budget)
    {
        this.budget = budget;
    }
}
