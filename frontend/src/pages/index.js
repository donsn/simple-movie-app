import { Navigate } from 'react-router-dom';
import LoginPage from './auth/login';
import SignupPage from './auth/signup';
import MovieListPage from './movies/all';
import SingleMoviePage from './movies/single';

export const Routes = [
    {
        path: '/',
        element: <Navigate to="/movies" />,
    },
    {
        path: '/movies',
        element: <MovieListPage />,
    },
    {
        path: '/movies/:slug',
        element: <SingleMoviePage />,
    },
    // Auth routes
    {
        path: '/login',
        element: <LoginPage />,
    },
    {
        path: '/register',
        element: <SignupPage />,
    }

]