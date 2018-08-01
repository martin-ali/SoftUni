package exercises;

import java.util.Objects;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class x16UrlParser
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);

        String url = console.nextLine();

        Pattern siteParser = Pattern.compile("(?<protocol>.+://)?(?<server>[a-zA-Z.]+)(?<resource>/.+)?");
        Matcher matcher = siteParser.matcher(url);

        if (matcher.find())
        {
            // Objects.toString -> if null, then become second argument
            String protocol = Objects
                                .toString(matcher.group("protocol"),"")
                                .replace("://", "");
            String server = matcher.group("server");
            String resource = Objects
                                .toString(matcher.group("resource"), "")
                                .replaceFirst("/","");

            System.out.println(String.format("[protocol] = \"%s\"", protocol));
            System.out.println(String.format("[server] = \"%s\"", server));
            System.out.println(String.format("[resource] = \"%s\"", resource));
        }
    }
}
/*
http://www.abc.com/video
 */