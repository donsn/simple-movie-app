import axios from "axios";
import { BASE_URL } from "../../api/base";

/**
 * Uploads an image file to the server
 * @param {File} file
 * @returns {Object} {url, uploaded}
 */
export const uploadImageAsync = async (file) => {
  try {
    let data = new FormData();
    data.append("file", file, file.name);
    const headers = {
      "Content-Type": "multipart/form-data",
    };


    const mainUrl = `${BASE_URL}/api/Movies/Image`;
    const response = await axios.post(mainUrl, data, {
      headers,
    });
    if (response.status === 200 || response.status === 204) {
      return {
        uploaded: true,
        url: response.data.data,
      };
    }
  } catch (err) {
    console.log(err, "an error occured trying to upload this image");
  }
  // if we get here, someting bad happened
  return {
    uploaded: false,
    url: null,
  };
};
