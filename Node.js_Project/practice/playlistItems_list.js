//플레이리스트에 등록된 동영상들의 정보 출력
var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

async function getPlaylistItemData(oauth2Client, playlistId) {
    const res = await service.playlistItems.list({
        auth: oauth2Client,
        part: 'snippet',
        fields: 'prevPageToken, nextPageToken, pageInfo, items(id, snippet(title, description, publishedAt))',
        maxResults: 40,
        playlistId: playlistId,
        pageToken: 'CCgQAA' //이전 페이지 값을 조회하고 싶은 경우 prevPageToken의 값을 입력
    });

    if (res.data.items == null || res.data.items.length === 0) {
        throw new Error("데이터가 존재하지 않습니다.");
    }

    return res.data;
}

oauth2Service.refreshClient()
    .then(client => getPlaylistItemData(client, "PLCDUk-Q4MTqywH_W4vzRXk-GMif8DGLMj"))
    .then(data => {
        console.log(JSON.stringify(data, null, 4));
    })
    .catch(console.error);