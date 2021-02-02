var {google} = require('googleapis');
var service = google.youtube('v3');
var ouath2Service = require('./common/oauth2_service');

const fs = require('fs');
const readline = require('readline');

async function insertPlaylistItem(ouath2Client, playlistId, videoId) {
    const res = await service.playlistItems.insert({
        auth: ouath2Client,
        part: 'snippet, contentDetails, status',
        requestBody: {
            snippet: {
                playlistId: playlistId,
                resourceId: {
                    kind: "youtube#video",
                    videoId: videoId
                }
            }
        }
    }
    );

    return res.data;
}

ouath2Service.refreshClient()
    .then(client => insertPlaylistItem(client, 'PLCDUk-Q4MTqwqGyuLoVTRXjCtZzGad1Pt', 'nJzBcKM3ZIE'))
    .then(data => console.log(JSON.stringify(data, null, 4)))
    .catch(err => {
        console.error("수행 중 에러가 발생했습니다.\n", err.errors);
    });