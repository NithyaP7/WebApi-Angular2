import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HistoryService } from '../../services/history/history.service';
import { History } from '../../models/history/history';

@Component({
    selector: 'history',
    template: require('./history.component.html'),
    styles: [require('./history.component.scss')]
})
export class HistoryComponent implements OnInit  {

    public histories: History[] = [];

    constructor(private _historyService: HistoryService) { }

    ngOnInit() {
        this._historyService.getUsers()
            .subscribe((data) => this.histories = data.histories);
    }
}
