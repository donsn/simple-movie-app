
/**
 * Slugifies a string
 * @param {String} text 
 */
export const slugify = (text) => {

    return text.toString().toLowerCase()
        .replace(/\s+/g, '-')           // Replace spaces with -
        .replace(/[^\w\\-]+/g, '')       // Remove all non-word chars
        .replace(/^-+/, '')             // Trim - from start of text
        .replace(/-+$/, '');            // Trim - from end of text
}