package javaBlog.config;

import javaBlog.entity.User;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.util.StringUtils;

import java.util.ArrayList;
import java.util.Collection;

public class BlogUserDetails extends User implements UserDetails
{
    private User user;

    private ArrayList<String> roles;

    public BlogUserDetails(User user, ArrayList<String> roles)
    {
        super(user.getEmail(), user.getFullName(), user.getPassword());

        this.user = user;
        this.roles = roles;
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities()
    {
        String userRoles = StringUtils.collectionToCommaDelimitedString(this.roles);

        return AuthorityUtils.commaSeparatedStringToAuthorityList(userRoles);
    }

    public User getUser()
    {
        return this.user;
    }

    @Override
    public String getUsername()
    {
        return user.getEmail();
    }

    @Override
    public boolean isAccountNonExpired()
    {
        return true;
    }

    @Override
    public boolean isAccountNonLocked()
    {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired()
    {
        return true;
    }

    @Override
    public boolean isEnabled()
    {
        return true;
    }
}
