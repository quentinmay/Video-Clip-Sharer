# 🎞 Video Clip Sharer

This is a basic video editor developed using C# and heavily dependent on FFmpeg and VLC libraries.

![output](https://user-images.githubusercontent.com/73214439/108961692-911a7180-762c-11eb-8781-235760ea8fc7.gif)

# 🚀Install
Installation program can be in [releases](https://github.com/quentinmay/Video-Clip-Sharer/releases).

## ⚠Requirements
1. [VLC Media Player](https://www.videolan.org/)
2. [FFmpeg](https://ffmpeg.org/)

All testing was done specifically with VLC 3.0.12 Vetinari and FFmpeg version 4.3.2-2021-02-27-essentials_build-www.gyan.dev and FFprobe version N-60329-ge708424. Other versions are not explicitly supported and may not work.


## VLC
axVLCPlugin is required in order to run the editor. This comes installed by default with VLC 3.0.12 Vetinari.

## FFmpeg
Tested specifically with FFmpeg and FFProbe binaries (FFmpeg version 4.3.2-2021-02-27-essentials_build-www.gyan.dev and FFprobe version N-60329-ge708424). Binaries by default will be placed in users temp folder.

## Noise Reduction Models
Included along with the ffmpeg binaries is a trained neural network model created by [GregorR](https://github.com/GregorR) that can be found [here](https://github.com/GregorR/rnnoise-models). When included in the application directory, ffmpeg can use this model to hopefully reduce background audio noise. I chose to use the conjoined-burgers-2018-08-28 model as it worked well for my samples.


## License
[MIT](https://choosealicense.com/licenses/mit/)
