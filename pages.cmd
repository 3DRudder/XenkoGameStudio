echo Create branch gh-pages
git branch gh-pages
git checkout gh-pages

echo Add remote pages
git remote add pages git@github.com:3DRudder/3dRudder.github.io.git
git fetch pages

echo Merge pages into gh-pages
git pull -Xours pages master --allow-unrelated-histories

echo Copy ReadMe.md into index.md
xcopy README.md index.md /Y