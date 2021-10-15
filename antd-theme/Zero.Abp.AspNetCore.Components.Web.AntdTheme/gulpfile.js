var gulp = require('gulp'),
    cleanCss = require('gulp-clean-css'),
    less = require('gulp-less'),
    rename = require('gulp-rename'),
    concatCss = require("gulp-concat-css"),
    npmImport = require("less-plugin-npm-import");
var replace = require('gulp-replace');

gulp.task('less', function () {
    return gulp
        .src([
            '**/*.less',
            '!styles/themes/**/*.less',
            '!node_modules/**/*.less'
        ])
        .pipe(less({
            javascriptEnabled: true,
            plugins: [new npmImport({ prefix: '~' })]
        }))
        .pipe(concatCss('abp-antdesign-blazor.css'))
        .pipe(cleanCss({ compatibility: '*' }))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('themes', function () {
    return gulp.src([
        'styles/themes/**/*.less',
        '!styles/themes/components.less',
    ])
        .pipe(less({
            javascriptEnabled: true,
            plugins: [new npmImport({ prefix: '~' })]
        }))
        .pipe(cleanCss({ compatibility: '*' }))
        .pipe(rename({ dirname: 'wwwroot/theme' }))
        //.pipe(replace(/#1890ff/g, function (match, p1) {
        //    return 'var(--primary-color)';
        //}))
        .pipe(gulp.dest('./'));
});

gulp.task('default', gulp.parallel('less', 'themes'), function () { });