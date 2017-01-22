//import
import {HistoryService} from './services/history/history.service';
import { ConnectionBackend } from '@angular/http';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
//provider
export const APP_PROVIDERS = [
    HttpModule,
    BrowserModule,
    ConnectionBackend,
    HistoryService
];