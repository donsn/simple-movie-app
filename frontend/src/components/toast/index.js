import { toast } from 'react-toastify';

/**
 * Shows a toast message
 * @param {string} type 
 * @param {string} message 
 */
export function showMessage(type, message){
    const toastOptions = {
        position: toast.POSITION.BOTTOM_CENTER,
        hideProgressBar: true,
        autoClose: 2500,
        closeButton: false
    }
    switch (type) {
        case MessageTypes.ERROR:
            toast.dark(message, {
                type: toast.TYPE.ERROR,
                ...toastOptions
            })
            break;
        case MessageTypes.SUCCESS:
            toast.dark(message, {
                type: toast.TYPE.SUCCESS,
                ...toastOptions
            })
            break;
        default:
            toast(message)
            break;
    }
}

/**
 * Message Types That Can Be Shown
 */
export const MessageTypes = {
    ERROR : "ERROR",
    SUCCESS: 'SUCCESS'
}