module.exports = function (grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        jshint: {
            files: ['app/**/*.js'],
            options: {
                globals: {
                    //jQuery: true
                }
            }
        },
        watch: {
            files: ['<%= jshint.files %>'],
            tasks: ['jshint']
        },
        less: {
            build: {
                files: {
                    '../Content/build/app.css': '../Content/template/all.less'
                }
            }
        },
        concat: {
            options: {
                // define a string to put between each file in the concatenated output
                separator: ''
            },
            libs: {
                src: ['libs/*.js'],
                dest: 'build/libs.js'
            },
            dist: {
                src: ['app/**/*.js'],
                dest: 'build/src.js'
            },
            css: {
                src: ['../Content/template/*.css'],
                dest: '../Content/build/app.css'
            },
            css: {
                src: ['../Content/template/*.less'],
                dest: '../Content/template/all.less'
            }
        },
        uglify: {
            options: {
                banner: '/*! <%= grunt.template.today("yyyy-mm-dd") %> */\n'
            },
            src: {
                src: 'build/src.js',
                dest: 'build/src.min.js'
            }
        },
        cssmin: {
            target: {
                files: [{
                    expand: true,
                    cwd: 'css',
                    src: ['*.css', '!*.min.css'],
                    dest: 'build',
                    ext: '.min.css'
                }]
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.registerTask('default', ['concat', 'less', 'uglify', 'cssmin']);
};