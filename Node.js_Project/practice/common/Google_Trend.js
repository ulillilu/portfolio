//Google Trend 인기 급상승 데이터 조회와 출력
'use strict';

const _ = require('lodash');
const Q = require('q');

const Parser = require('rss-parser');
const parser = new Parser({
    customFields: {
        item: ['ht:approx_traffic', 'ht:picture', 'ht:news_item']
    }
});

const moment = require('moment-timezone');
moment.locale('ko');
const TIMEZONE = "Asia/Seoul";
const DATE_FORMAT = "2020-08-18";//조회하고 싶은 날짜 입력

class GoogleTrendsService {
    constructor(options) {
        this._options = options || {};
        this.rss = 'http://trends.google.com/trends/trendingsearches/daily/rss?geo=KR';
    }
    getDailySearchTrends() {
        var deferred = Q.defer();

        parser.parseURL(this.rss)
            .then(feed => {
                let googleTrendsData = {
                    'items': []
                };

                feed.items.forEach(item => {
                    let today = moment().tz(TIMEZONE).format(DATE_FORMAT);
                    let trendsDate = moment(item.isoDate).tz(TIMEZONE).format(DATE_FORMAT);

                    if (today == trendsDate) {
                        googleTrendsData.items.push({
                            'title': item.title,
                            'count': item['ht:approx_traffic'],
                            'pubDate': item.pubDate,
                            'pubDateKor': moment(item.isoDate).tz(TIMEZONE).format("LLLL"),
                            'isoDate': item.isoDate,
                            'picture': item['ht:picture'],
                            'newsItemTitle': _.unescape(item['ht:news_item']["ht:news_item_title"][0]),
                            'newsItemSnippet': _.unescape(item['ht:news_item']["ht:news_item_snippet"][0]),
                            'newsItemUrl': _.unescape(item['ht:news_item']["ht:news_item_url"][0]),
                            'newsItemSource': _.unescape(item['ht:news_item']["ht:news_item_source"][0])
                        });
                    }
                });
                deferred.resolve(googleTrendsData);
            }).catch(err => {
                deferred.reject(err);
            });
        return deferred.promise;
    }
}

module.exports = new GoogleTrendsService();