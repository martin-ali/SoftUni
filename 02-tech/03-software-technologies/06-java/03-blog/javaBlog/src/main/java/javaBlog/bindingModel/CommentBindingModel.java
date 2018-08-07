package javaBlog.bindingModel;

import javax.validation.constraints.NotNull;

public class CommentBindingModel
{
    @NotNull
    private String content;

    @NotNull
    public String getContent()
    {
        return content;
    }

    public void setContent(@NotNull String content)
    {
        this.content = content;
    }
}
