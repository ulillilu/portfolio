//국내 뉴스 카테고리 대표적 채널 조회

var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

function getChannelListData(oauth2Client, categoryId) {
    service.channels.list({
        auth: oauth2Client,
        part: 'id, snippet',
        fields: 'items(id, snippet(title))',
        categoryId: categoryId,
        maxResults: 3
    }, function(err, response) {
        if (err) {
            console.log('The API returned an error: ' + err);
            return;
        }
        var channels = response.data.items;
        if (channels.length == 0) {
            console.log('No channel found.');
        } else {
            console.log(JSON.stringify(channels, null, 4));
        }
    });
}

oauth2Service.refreshClient()
    .then((client) => {
        getChannelListData(client, 'GCTmV3cyAmIFBvbGl0aWNz');
    })
    .catch(console.error);