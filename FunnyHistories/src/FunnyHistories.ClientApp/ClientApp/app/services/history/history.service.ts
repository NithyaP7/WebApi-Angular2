import { Injectable } from '@angular/core';
import { HttpModule, Http, Headers, Response, RequestOptions, BaseRequestOptions, RequestMethod } from "@angular/http";
import '../../rxjs-extensions.ts';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class HistoryService {

    private _url: string = 'http://localhost:64862/api/history';

    private headers = new Headers();
    private options = new RequestOptions({ headers: this.headers });
    
    constructor(private _http: Http) {
        this.headers.set('Access-Control-Allow-Origin', '*');
        this.headers.set('Access-Control-Allow-Credentials', 'true');
        this.headers.set('Content-Type','application/json');
    }


    getUsers() /*: Observable<any[]>*/ {
        return this._http.get(this._url,this.options)
            .map((resp: Response) => resp.json())
            .do(data => console.log('server data:', data))  // debug
            .catch(this.handleError)
    };

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}