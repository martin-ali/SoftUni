function solve()
{
    class Post
    {
        title;
        content;

        constructor(title, content)
        {
            this.title = title;
            this.content = content;
        }

        toString()
        {
            const result = `Post: ${this.title}` +
                `\nContent: ${this.content}`;

            return result;
        }
    }

    class SocialMediaPost extends Post
    {
        likes;
        dislikes;
        comments;

        constructor(title, content, likes, dislikes)
        {
            super(title, content);

            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment)
        {
            this.comments.push(comment);
        }

        toString()
        {
            const rating = this.likes - this.dislikes;
            let result = super.toString();

            result += `\nRating: ${rating}`;

            if (this.comments.length !== 0)
            {
                result += '\nComments:';
            }

            for (const comment of this.comments)
            {
                result += '\n';
                result += ` * ${comment}`;
            }

            return result;
        }
    }

    class BlogPost extends Post
    {
        views;

        constructor(title, content, views)
        {
            super(title, content);

            this.views = views;
        }

        view()
        {
            this.views++;

            return this;
        }

        toString()
        {
            let result = super.toString();

            result += `\nViews: ${this.views}`;

            return result;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}