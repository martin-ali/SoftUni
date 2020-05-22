 function getArticleGenerator(articles)
 {
     return function ()
     {
         if (articles.length === 0)
         {
             return;
         }

         const currentArticle = articles.shift();
         const contentDiv = document.getElementById('content');
         const articleHtml = document.createElement('article');

         articleHtml.textContent = currentArticle;
         contentDiv.appendChild(articleHtml);
     }
 }