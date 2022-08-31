const urlconfig = {


    host() {
        return "https://colams.herokuapp.com/"
    },

    url(path) {
        var tempPath = path;
        if (path.indexOf("/") == 0) {
            tempPath = path.slice(1);
        }
        return this.host() + tempPath
    }

}

export default urlconfig;
