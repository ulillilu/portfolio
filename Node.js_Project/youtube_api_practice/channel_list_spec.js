var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

function getChannelListData(oauth2Client, channelId) {
    service.channels.list({
        auth: oauth2Client,
        part: 'id, snippet, statistics',
        fields: 'items(id, snippet(title, description, thumbnails(default(url))), statistics(viewCount, subscriberCount, videoCount))',
        id: channelId
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
        getChannelListData(client, 'UClUE7d0UQ7dhLjK1r6xpG9w');
    })
    .catch(console.error);