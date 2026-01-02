export function beforeStart(options) {
    console.log("before start");
}

export async function afterStarted(blazor) {
    console.log("after started");
    
    // Note: Dynamic root component addition has changed in .NET 9
    // Commented out until the correct API is determined
    // See: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/dynamically-add-components
    
    /*
    let element = document.getElementById('alertContainer');
    
    if (element) {
        try {
            await blazor.rootComponents.add(element, 'globalAlert', {
                title: "Hello!",
                message: "This was rendered via JavaScript"
            });
        } catch (error) {
            console.error("Error adding root component:", error);
        }
    } else {
        console.error("alertContainer element not found");
    }
    */
}