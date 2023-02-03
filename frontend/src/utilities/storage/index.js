import * as localForage from "localforage";

/**
 * Saves an item to local storage
 * @param {String} key 
 * @param {Object} content 
 */
export async function saveContent (key, content) {
    try {
        await localForage.setItem(key, content);
    } catch (err) {
        // This code runs if there were any errors.
        // console.log(err);
    }
}

/**
 * Gets an item from storage
 * @param {String} key 
 */
 export async function retrieveContent(key) {
    try {
        return await localForage.getItem(key);
    } catch (err) {
        // This code runs if there were any errors.
        // console.log(err);
    }
    return null;
}