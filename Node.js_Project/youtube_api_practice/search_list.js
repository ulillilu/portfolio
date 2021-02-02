const {google} = require('googleapis');
const service = google.youtube('v3');
const oauth2Service = require('./common/oauth2_service');
const _ = require('lodash');

async function getSearchList(oauth2Client, channelId) {
  const res = await service.search.list({
    auth: oauth2Client,
    channelId: channelId,
    maxResults: 5, //검색 결과 개수
    type: 'video',
    order: 'viewCount', //데이터 정렬 기준
    part: 'id',
    //q: '이슈', //검색 키워드
    publishedAfter: '2015-01-01T00:00:00Z', //검색 범위 시작 날짜
    publishedBefore: '2020-08-18T23:59:59Z', //검색 범위 종료 날짜
    fields: 'items(id(videoId))'
  });

  if (res.data.items == null || res.data.items.length === 0) {
    throw new Error("데이터가 존재하지 않습니다.");
  }

  return res.data;
}

async function getVideoList(oauth2Client, videoIds) {
  const res = await service.videos.list({
    auth: oauth2Client,
    id: videoIds,
    part: 'snippet, statistics, contentDetails',
    fields: 'items(id, snippet(title, description, publishedAt), statistics(viewCount, commentCount, likeCount))'
  });

  if (res.data.items == null || res.data.items.length === 0) {
    throw new Error("데이터가 존재하지 않습니다.");
  }

  return res.data;
}

async function startSearch() {
  let client = await oauth2Service.refreshClient();

  let searchList = await getSearchList(client, "UClUE7d0UQ7dhLjK1r6xpG9w");
  let videoIdList = _.map(searchList.items, "id.videoId").join();
  let videoList = await getVideoList(client, videoIdList);

  console.log(JSON.stringify(videoList, null, 4));
} //검색 수행 함수

startSearch().catch(console.error);