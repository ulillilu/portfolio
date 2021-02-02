//채널에 등록된 재생목록들의 제목과 설명 대표 이미지 출력

var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

function getChannelListData(oauth2Client, channelId) {
    service.playlists.list({
        auth: oauth2Client,
        part: 'id, snippet',
        fields: 'items(id, snippet(title, description, thumbnails(default(url))))',
        channelId: channelId
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