import { retrieveContent } from "../utilities/storage";

/**
 * Hook that checks if a user is authenticated
 */
export const useAuthentication = () => {
    const token = retrieveContent("xtoken");
    if (token) {
        return {
            authenticated: true
        }
    }
    return {
        authenticated: false
    }
}