var gulp = require('gulp');
var sass = require('gulp-sass');

var cssDest = 'wwwroot/css';
var cssInputFile = 'wwwroot/style.scss';

gulp.task('buildcss', function () {
    return gulp.src(cssInputFile)
        .pipe(sass({
            outputStyle: 'compressed'
        }))
        .pipe(gulp.dest(cssDest));
});