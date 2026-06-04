import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '10s', target: 5 },   
        { duration: '30s', target: 10 },  
        { duration: '10s', target: 0 },   
    ],
    thresholds: {
        http_req_duration: ['p(95)<3000'], 
        http_req_failed:   ['rate<0.01'],  
    },
};

export default function () {
    const res = http.get('http://localhost:5191');
    check(res, {
        'status is 200': (r) => r.status === 200,
        'load time < 3s': (r) => r.timings.duration < 3000,
    });
    sleep(1);
}