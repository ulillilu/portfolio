var {google} = require('googleapis');
// const { resolve } = require('path');
// const { rejects } = require('assert');
var url  = require('url');
var http = require('http');
var open = require('open');
var destroyer = require('destroyer');
var destroy = require('destroy');
var oauth2Service = {};

const oauth2Client = new google.auth.OAuth2(
    "322397189412-oa9pvg06mlm4ogjpcgaamfdnri4nrb65.apps.googleusercontent.com",
    "iVLCv-nNJo_mDn6RZUHNvK-R",
    "http://localhost:3031/api/oauth2callback"
);

const scopes = [
    'https://www.googleapis.com/auth/youtube',
    'https://www.googleapis.com/auth/youtube.force-ssl',
    'https://www.googleapis.com/auth/youtube.readonly',
    'https://www.googleapis.com/auth/youtubepartner',
    'https://www.googleapis.com/auth/youtube.upload',
    'https://www.googleapis.com/auth/yt-analytics.readonly',
    'https://www.googleapis.com/auth/yt-analytics-monetary.readonly'
];
let refreshToken ='1//0ePZkLku5nARMCgYIARAAGA4SNwF-L9Ir4EIpxZd5Cs5_ZI-ZweusWvBWu0-qinXRi_8aOYggZ5sJPHnST5HrEUa7kCjaOe0FjUs';

oauth2Service.refreshClient = async function refreshClient() {

    return new Promise((resolve, reject) => {

        if (refreshToken !== "1//0ePZkLku5nARMCgYIARAAGA4SNwF-L9Ir4EIpxZd5Cs5_ZI-ZweusWvBWu0-qinXRi_8aOYggZ5sJPHnST5HrEUa7kCjaOe0FjUs") {
            oauth2Client.setCredentials({
                refresh_token:refreshToken
            });

            oauth2Client.getAccessToken((err, token) => {
                if (err) {
                    reject(e);
                }
                resolve(oauth2Client);
            });
        } else {
            const authorizeUrl = oauth2Client.generateAuthUrl({
                access_type: 'offline',
                scope:scopes.join(' '),
            });
            const server = http.createServer(async (req, res) => {
                try {
                    if (req.url.indexOf('/api/oauth2callback') > -1) {
                        const qs = new url.URL(req.url, 'http://localhost:3031').searchParams;
                        res.end('인증 완료');
                        server.destroy;

                        const {
                            tokens
                        } = await oauth2Client.getToken(qs.get('code'));
                        
                        refreshToken = tokens.refresh_token;
                        oauth2Client.credentials = tokens;

                        resolve(oauth2Client);
                    }
                } catch (e) {
                    reject(e);
                }
            }).listen(3031, () => {
                open(authorizeUrl, {
                    wait: false
                }).then(cp => cp.unref());
            });
            destroyer(server);
        }
    });
}

module.exports = oauth2Service;