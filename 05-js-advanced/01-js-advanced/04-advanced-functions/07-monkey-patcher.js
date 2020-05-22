function solution(command)
{
    const execute = {
        upvote: post => post.upvotes++,
        downvote: post => post.downvotes++,
        score: post =>
        {
            const totalVotes = post.upvotes + post.downvotes;
            const greaterVotes = post.upvotes > post.downvotes
                ? post.upvotes
                : post.downvotes;
            const upvotesShown = totalVotes > 50
                ? Math.ceil(post.upvotes + (greaterVotes / 4))
                : post.upvotes;
            const downvotesShown = totalVotes > 50
                ? Math.ceil(post.downvotes + (greaterVotes / 4))
                : post.downvotes;
            const balance = post.upvotes - post.downvotes;
            let rating = 'new';

            if (totalVotes < 10)
            {
                rating = 'new';
            }
            else if (post.upvotes > (totalVotes * 0.66))
            {
                rating = 'hot'
            }
            else if (balance < 0)
            {
                rating = 'unpopular';
            }
            else if (balance >= 0 && (post.upvotes > 100 || post.downvotes > 100))
            {
                rating = 'controversial';
            }

            return [upvotesShown, downvotesShown, balance, rating];
        }
    }

    return execute[command](this);
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

console.log(solution.call(post, 'upvote'));
console.log(solution.call(post, 'downvote'));
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
for (let i = 1; i <= 50; i++)
{
    solution.call(post, 'downvote'); // (executed 50 times)}
}
score = solution.call(post, 'score'); // [139, 189, -50, 'unpopular']
console.log(score);


let forumPost = {
    id: '1234',
    author: 'author name',
    content: 'these fields are irrelevant',
    upvotes: 4,
    downvotes: 5
};

// // // Under border case
// var answer = result.call(forumPost, 'score');
// var expected = [4, 5, -1, 'new'];
// console.log(answer);
// console.log(expected);

// // Past border case
// result.call(forumPost, 'downvote');
// answer = result.call(forumPost, 'score');
// expected = [4, 6, -2, 'unpopular'];
// console.log();
// console.log(answer);
// console.log(expected);

// result.call(forumPost, 'upvote');
// result.call(forumPost, 'upvote');
// answer = result.call(forumPost, 'score');
// expected = [6, 6, 0, 'new'];
// console.log();
// console.log(answer);
// console.log(expected);

// // 38 Upvotes
// for (let i = 0; i < 38; i++)
// {
//     result.call(forumPost, 'upvote');
// }
// answer = result.call(forumPost, 'score');
// expected = [44, 6, 38, 'hot'];
// console.log();
// console.log(answer);
// console.log(expected);


// // Past obfuscation threshold
// result.call(forumPost, 'downvote');
// answer = result.call(forumPost, 'score');
// expected = [55, 18, 37, 'hot'];
// console.log();
// console.log(answer);
// console.log(expected);

// // Bellow hot threshold
// forumPost.upvotes = 132;
// forumPost.downvotes = 68;

// answer = result.call(forumPost, 'score');
// expected = [165, 101, 64, 'controversial'];
// console.log();
// console.log(answer);
// console.log(expected);

// // Past hot threshold
// forumPost.upvotes = 133;

// answer = result.call(forumPost, 'score');
// expected = [167, 102, 65, 'hot'];
// console.log();
// console.log(answer);
// console.log(expected);

// -

// var forumPost = {
//     id: '2',
//     author: 'gosho',
//     content: 'whats up?',
//     upvotes: 120,
//     downvotes: 30
// };

// var answer = result.call(forumPost, 'score');
// var expected = [150, 60, 90, 'hot'];

// expect(forumPost.upvotes).to.equal(120, 'Actual upvotes where manipulated');
// expect(forumPost.downvotes).to.equal(30, 'Actual downvotes where manipulated');

// compareScore(expected, answer);

// function compareScore(expected, answer)
// {
//     expect(expected[0]).to.equal(answer[0], 'Incorrect number of upvotes');
//     expect(expected[1]).to.equal(answer[1], 'Incorrect number of downvotes');
//     expect(expected[2]).to.equal(answer[2], 'Incorrect score');
//     expect(expected[3]).to.equal(answer[3], 'Incorrect rating');
// }