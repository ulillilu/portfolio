//비디오 정보 추출
var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');

async function getVideoInfo(oauth2Client, videoId) {
    const res = await service.videos.list({
        auth: oauth2Client,
        id: videoId,
        part: 'snippet, statistics, contentDetails',
        fields: 'items(id, snippet(title, description), statistics(viewCount, commentCount, likeCount), contentDetails(caption))'
    });

    if (res.data.items == null || res.data.items.length === 0) {
        throw new Error("데이터가 존재하지 않습니다.");
    }

    return res.data;
}

oauth2Service.refreshClient()
    .then(client => getVideoInfo(client, "IPXIgEAGe4U"))
    .then(result => console.log(JSON.stringify(result, null, 4)))
    .catch(error => console.error);