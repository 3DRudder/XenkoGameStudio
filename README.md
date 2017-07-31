# 3dRudder custom theme based on jekyll theme [slate](https://pages-themes.github.io/slate/)

# Get theme in other repo

* create new branch: "gh-pages"
* add remote "pages" : git remote add pages git@github.com:3DRudder/3dRudder.github.io.git
* pull/merge "pages" into branch "gh-pages" : 'git checkout gh-pages' and 'git pull pages master --allow-unrelated-histories'
* resolve conflics (ReadMe.md keep yours)
* copy/past the content of master "ReadMe.md" into the "index.md"
* push (maybe force push if fail)
* look the result on 3dRudder.github.io/name_of_repo

# Update theme

* go to your "gh-pages" branch
* pull/merge : 'git pull pages master --allow-unrelated-histories'
* resolve conflics
* copy/past the content of master "ReadMe.md" into the "index.md"
* push

# Test in local

* Open cmd or bash on root of project
* Check ruby is installed : 'ruby --version'
* Install bundle : 'bundle install'
* Install jekyll : 'gem install jekyll bundler'
* Add in _config.yml 'repository: 3dRudder/project_name'
* Launch server : 'bundle exec jekyll serve'
* Test : 'http://127.0.0.1:4000/'

# Soon
* launch .bat or .cmd to update automaticaly
