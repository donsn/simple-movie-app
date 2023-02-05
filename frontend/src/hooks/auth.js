import { useState } from "react";
import { retrieveContent } from "../utilities/storage";

/**
 * Hook that checks if a user is authenticated
 */
export const useAuthentication = () => {
    const [authenticated, setAuthenticated] = useState(false);
    retrieveContent("x-token").then((token) => {
        if (token) {
            setAuthenticated(true);
        }
    });

    return {
        authenticated
    }
}