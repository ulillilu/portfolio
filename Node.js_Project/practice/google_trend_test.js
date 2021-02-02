const trendsService = require('./common/Google_Trend');

trendsService.getDailySearchTrends()
    .then(trendsList => {
        console.log(JSON.stringify(trendsList, null, 2));
    })
    .catch(err => console.err);
;