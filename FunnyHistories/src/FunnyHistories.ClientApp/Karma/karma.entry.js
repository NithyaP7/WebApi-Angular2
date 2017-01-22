require('es6-shim');
require('zone.js/dist/zone')
require('zone.js/dist/long-stack-trace-zone')
require('zone.js/dist/async-test')
require('zone.js/dist/fake-async-test')
require('zone.js/dist/sync-test')
require('zone.js/dist/proxy')
require('zone.js/dist/jasmine-patch')
require('reflect-metadata');

//require('core-js');
//test defines
//require('../ClientApp/test/main.spec.ts');

const browserTesting = require('@angular/platform-browser-dynamic/testing');
const coreTesting = require('@angular/core/testing');

coreTesting.TestBed.resetTestEnvironment();
coreTesting.TestBed.initTestEnvironment(
    browserTesting.BrowserDynamicTestingModule,
    browserTesting.platformBrowserDynamicTesting()
);
const context = require.context('../ClientApp/test/', true, /\.spec.ts$/);
context.keys().map(context)


Error.stackTraceLimit = Infinity;
jasmine.DEFAULT_TIMEOUT_INTERVAL = 2000;

context.keys().forEach(context);

//describe('sub test', () => {
//    it('always fails', () => {
//        expect(0).toBe(1);
//    });
//});