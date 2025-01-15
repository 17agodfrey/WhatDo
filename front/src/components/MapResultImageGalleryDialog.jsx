import React from 'react';
import Dialog from '@mui/material/Dialog';
import DialogContent from '@mui/material/DialogContent';
import ImageGallery from "../components/ImageGallery";

const MapResultImageGalleryDialog = ({ open, onClose, imageUrls }) => {
    return (
        <Dialog open={open} onClose={onClose} maxWidth="lg" fullWidth sx={{maxHeight: '100%'}}>
            <DialogContent sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                <ImageGallery _imageUrls={imageUrls} />
            </DialogContent>
        </Dialog>
    );
};

export default MapResultImageGalleryDialog;