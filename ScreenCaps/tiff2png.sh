
cp *.tiff ./tiff_backups

for file in *.tiff
do
  convert $file -resize 40% ${file%.*}.png
done
