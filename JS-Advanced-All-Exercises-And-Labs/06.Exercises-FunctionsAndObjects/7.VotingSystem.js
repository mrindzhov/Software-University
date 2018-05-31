function votingSystem(action) {
    let obj = this;
    let patcher = (function () {
        function upvote() {
            obj.upvotes++;
        }

        function downvote() {
            obj.downvotes++;
        }

        function fakeRecords(num) {
            return 0.25 * num;
        }

        function calculateRating() {
            let totalVotes = obj.upvotes + obj.downvotes;
            if (totalVotes >= 10) {
                if (obj.upvotes / totalVotes > 0.66) {
                    return 'hot';
                } else if (obj.upvotes - obj.downvotes >= 0 && obj.upvotes > 100 || obj.downvotes > 100) {
                    return 'controversial';
                } else if (obj.upvotes - obj.downvotes < 0) {
                    return 'unpopular';
                }
            }

            return 'new';
        }

        function score() {
            let up = obj.upvotes;
            let down = obj.downvotes;

            let totalScore = obj.upvotes - obj.downvotes;
            if (obj.upvotes + obj.downvotes > 50) {
                let additionalVotes = fakeRecords(Math.max(obj.upvotes, obj.downvotes));
                up = Math.ceil(obj.upvotes + additionalVotes);
                down = Math.ceil(obj.downvotes + additionalVotes);
            }

            let rating = calculateRating();

            return [up, down, totalScore, rating];
        }

        return {upvote, downvote, score};
    })();

    return patcher[action]();
}