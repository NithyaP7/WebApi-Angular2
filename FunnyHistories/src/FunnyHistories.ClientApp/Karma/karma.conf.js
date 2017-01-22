'use strict';

module.exports = (config) => {
    config.set({
        frameworks: ['jasmine'],
        browsers: ['Chrome'],
        files: [
           '../node_modules/es6-shim/es6-shim.min.js',
           'karma.entry.js',
        ],
        plugins: [
          require('karma-jasmine'),
          require('karma-chrome-launcher'),
          require('karma-jasmine-html-reporter'), // click "Debug" in browser to see it
          require('karma-htmlfile-reporter'),
          require('karma-sourcemap-loader'),
          require('karma-webpack'), // crashing w/ strange socket error
        ],
        reporters: ['progress', 'kjhtml'],//'html'],

        // HtmlReporter configuration
        htmlReporter: {
            // Open this file to see results in browser
            outputFile: 'test/tests.html',

            // Optional
            pageTitle: 'Unit Tests',
            subPageTitle: __dirname
        },
        //reporters: ['progress'],
        logLevel: config.LOG_INFO,
        phantomJsLauncher: {
            exitOnResourceError: true
        },
        preprocessors: {
            'karma.entry.js': ['webpack', 'sourcemap']
        },
        singleRun: false,
        colors: true,
        autoWatch: true,
        webpack: require('../webpack/webpack.test'),
        webpackServer: {
            noInfo: true
        }


    })
}