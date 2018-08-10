package cat.bindingModel;

import javax.validation.constraints.NotNull;

public class CatBindingModel
{
    private String name;

    private String nickname;

    private double price;

    @NotNull
    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    @NotNull
    public String getNickname()
    {
        return nickname;
    }

    public void setNickname(String nickname)
    {
        this.nickname = nickname;
    }

    @NotNull
    public double getPrice()
    {
        return price;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }
}
