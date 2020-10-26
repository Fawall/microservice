function Cities(){
    let select = document.getElementById('capital');
    let value = select[select.selectedIndex].value;
    
    return value;
}

let DivCity = document.getElementById("city");
let DivTemp = document.getElementById("temp");
let DivMusic = document.getElementById("music");

function GetUrl(){

    let uri = `http://localhost:5000/api/temperature/${Cities()}`
      
    fetch(uri, {method: "GET"}).then(function(response){
        
        return response.text().then(function(text){
            const cidadeInfo = JSON.parse(text)

            DivCity.innerHTML = cidadeInfo.city;
            DivTemp.innerHTML = cidadeInfo.temp;
            DivMusic.innerHTML = cidadeInfo.music;
        });
    });
               // async x => await x.text()
    
        

    


}