var gulp = require('gulp');
var sass = require('gulp-sass');

var cssDest = 'wwwroot/css';
var cssInputFile = 'wwwroot/custom/style.scss';
var watchedFiles = 'wwwroot/custom/**/*.scss'

gulp.task('buildcss', function () {
    return gulp.src(cssInputFile)
        .pipe(sass({
            outputStyle: 'compressed'
        }))
        .pipe(gulp.dest(cssDest));
});

gulp.task(watchedFiles, ['buildcss']);