/// <binding AfterBuild='default' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify'),
    rename = require('gulp-rename');


var paths = {
    bootstrapCss: './bower_components/bootstrap/dist/css/bootstrap.css',
    bootstrapSbAdminCss: './bower_components/startbootstrap-sb-admin-2/dist/css/sb-admin-2.css',
    bootstrapTimelineCss: './bower_components/startbootstrap-sb-admin-2/dist/css/timeline.css',

    bootstrapJs: './bower_components/bootstrap/dist/js/bootstrap.js',
    bootstrapSbAdminJs: './bower_components/startbootstrap-sb-admin-2/dist/js/sb-admin-2.js',
    jqueryJs: './bower_components/jquery/dist/bootstrap.js',

    jsDest: './wwwroot/js',
    cssDest: './wwwroot/css',
    fontDest: './wwwroot/font'

};


gulp.task('min:js', function() {
    return gulp.src([paths.jqueryJs, paths.bootstrapJs, paths.bootstrapSbAdminJs])
        .pipe(concat(paths.jsDest + '/min/site.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('.'));
});

gulp.task('min:css', function() {
    return gulp.src([paths.bootstrapCss, paths.bootstrapTimelineCss, paths.bootstrapSbAdminCss])
        .pipe(concat(paths.cssDest + '/min/site.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest('.'));
});

gulp.task('copy:css', function () {
    return gulp.src([paths.bootstrapCss, paths.bootstrapTimelineCss, paths.bootstrapSbAdminCss])
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task('copy:js', function () {
    return gulp.src([paths.jqueryJs, paths.bootstrapJs, paths.bootstrapSbAdminJs])
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task('min', ['min:js', 'min:css']);
gulp.task('copy', ['copy:js', 'copy:css']);

gulp.task('default', ['copy', 'min']);
