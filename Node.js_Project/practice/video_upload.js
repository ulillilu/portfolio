var {google} = require('googleapis');
var service = google.youtube('v3');
var oauth2Service = require('./common/oauth2_service');
const fs = require('fs');
const readline = require('readline');

async function insertVideo(client, fileName) {
    const fileSize = fs.statSync(fileName).size;
    const res = await service.videos.insert({
      auth: client,
      part: 'id,snippet,status',
      autoLevels: true,
      requestBody: {
        snippet: {
          title: '유튜브 API를 사용한 동영상 업로드',
          description: '유튜브의 Videos API를 사용하여 mp4 동영상을 업로드합니다.',
          tags: ['유튜브API', '동영상업로드', 'videos.insert']
        },
        status: {
          privacyStatus: 'private',
        },
      },
      media: {
        body: fs.createReadStream(fileName),
      },
    }, {
      onUploadProgress: evt => {
        const progress = (evt.bytesRead / fileSize) * 100;
        readline.clearLine(process.stdout, 0);
        readline.cursorTo(process.stdout, 0, null);
        process.stdout.write(`${Math.round(progress)}% 완료`);
      },
    });
  
    console.log('\n\n');
    return res.data;
  }

  oauth2Service.refreshClient()
    .then(client => insertVideo(client, 'test.mp4'))
    .then(data => console.log(JSON.stringify(data, null, 4)))
    .catch(err => {
        console.error("수행중 에러가 발생했습니다.\n", err);
    }
);