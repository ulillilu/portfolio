//플레이리스트 내의 비디오ID 추출
var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

async function getPlaylistItemVideoData(oauth2Client, playlistId) {
    const res = await service.playlistItems.list({
        auth: oauth2Client,
        part: 'snippet',
        fields: 'items(snippet(title, resourceId(videoId)))',
        maxResults: 3,
        playlistId: playlistId,
    });

    if (res.data.items == null || res.data.items.length === 0) {
        throw new Error("데이터가 존재하지 않습니다.");
    }

    return res.data;
}

oauth2Service.refreshClient()
    .then(client => getPlaylistItemVideoData(client, "PLCDUk-Q4MTqywH_W4vzRXk-GMif8DGLMj"))
    .then(data => {
        console.log(JSON.stringify(data, null, 4));
    })
    .catch(console.error);