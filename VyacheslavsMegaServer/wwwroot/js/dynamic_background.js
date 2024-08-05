initImg('#test img', [
    'https://picsum.photos/id/1001/800/300',
    'https://picsum.photos/id/1002/800/300',
    'https://picsum.photos/id/1006/800/300',
    'https://picsum.photos/id/1004/800/300',
    'https://picsum.photos/id/1005/800/300'
]);

function initImg(selector, srcArr) {
    const img = document.querySelector(selector);
    Object.assign(img, {
        buf: Object.assign(new Image(), { img }),
        srcArr: [...srcArr],
        changeInterval: 5e3,
        bufIdx: 0,
        change: function () {
            this.style.animationName = 'img-in';
            this.src = this.buf.src || this.nextImage();
            this.buf.src = this.nextImage();
        },
        nextImage: function () {
            this.bufIdx = ++this.bufIdx < this.srcArr.length ? this.bufIdx : 0;
            return this.srcArr[this.bufIdx];
        }
    });
    img.buf.addEventListener('load', loadHandler);
    img.addEventListener('animationend', animEndHandler);
    img.change();
    return img;

    function loadHandler() {
        setTimeout(
            () => this.img.style.animationName = 'img-out',
            this.img.changeInterval
        );
    }
    function animEndHandler({ animationName }) {
        if (animationName === 'img-out')
            this.change();
    }
}