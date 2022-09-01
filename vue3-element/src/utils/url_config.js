const haipi = {
    list: "api/haipi/list",
    delete: "api/haipi/delete",
}

const database = {
    conn: "api/database/conn",
}

const urlconfig = {

    haipi: haipi,
    database: database,

    host() {
        return "https://colaml.herokuapp.com/"
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
