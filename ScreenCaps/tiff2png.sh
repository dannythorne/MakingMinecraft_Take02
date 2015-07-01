
#cp *.tiff ./tiff_backups

for file in *.tiff
do
  convert $file -resize 40% ${file%.*}.png

  if [ ! -f tiff_backups/$file ]; then
    echo "Backing up $file";
    cp $file ./tiff_backups
  fi
done
