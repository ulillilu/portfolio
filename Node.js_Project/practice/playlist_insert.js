// 새로운 재생목록을 추가하는 코드
var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

async function getPlaylistData(oauth2Client) {
    const res = await service.playlists.insert({
        auth: oauth2Client,
        part: 'id, snippet, status',
        requestBody: {
            snippet: {
                title: 'API로 만든 재생목록',
                description: 'Youtube Data API를 통해서 만든 임시 재생목록'
            }
        }
    }
    );
    return res.data;
}

oauth2Service.refreshClient()
    .then(client => getPlaylistData(client))
    .then(data => console.log(JSON.stringify(data, null, 4)))
    .catch(console.error);