<template>
  <v-container fluid id="screen">
    <v-container class="home">
      <v-carousel height="550">
        <v-carousel-item v-for="(pic, index) in pictures" :key="index" :src="pic.src"></v-carousel-item>
      </v-carousel>

      <!--  -->
      <v-row class="mt-5">
        <v-col v-for="(val, index) in cards" :key="index" cols="12" lg="3">
          <v-card class="mx-auto" max-width="400">
            <v-img class="white--text align-end" height="200px" :src="val.src">
              <v-card-title>{{ val.title }}</v-card-title>
            </v-img>

            <v-card-subtitle class="pb-0">{{ val.subtitle }}</v-card-subtitle>

            <v-card-text v-html="val.text" class="text--primary mb-3"> </v-card-text>

            <v-card-actions>
              <v-btn color="orange" text>
                Share
              </v-btn>

              <v-btn color="orange" text>
                Explore
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>

      <v-row class="mt-5">
        <v-col class="posts" cols="12" lg="8">
          <v-app-bar dense>
            <v-avatar>
              <v-icon>fas fa-graduation-cap</v-icon>
            </v-avatar>
            <v-toolbar-title>Student response</v-toolbar-title>
          </v-app-bar>
          <v-card v-for="(val, index) in posts" :key="index" class="mt-5">
            <v-row>
              <v-col cols="12" lg="3">
                <v-img aspect-ratio="1.5" :src="val.src"></v-img>
              </v-col>
              <v-col cols="12" lg="9">
                <v-card-title>
                  {{ val.title }}
                </v-card-title>
                <v-card-text class="text--primary mb-3">
                  <div>{{ val.text }}</div>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn class="cardBtn rounded-pill" color="pink lighten-3">READ MORE</v-btn>
                </v-card-actions>
              </v-col>
            </v-row>
          </v-card>
        </v-col>

        <v-col cols="12" lg="4">
          <v-app-bar color="indigo" class="rounded-pill" dense dark>
            <v-avatar>
              <v-icon>fas fa-user</v-icon>
            </v-avatar>
            <v-toolbar-title>About & Social</v-toolbar-title>
          </v-app-bar>

          <v-card class="mt-4">
            <v-img class="white--text align-end" height="300px" src="https://cdn.vuetifyjs.com/images/cards/docks.jpg">
              <v-card-title>Top 10 Australian beaches</v-card-title>
            </v-img>
          </v-card>

          <v-row>
            <v-col v-for="(val, index) in links" :key="index" cols="12" lg="4">
              <v-row justify="center">
                <v-btn width="75%" class="rounded-pill" :color="val.color"
                  ><v-icon color="white">{{ val.icon }}</v-icon></v-btn
                >
              </v-row>
            </v-col>
          </v-row>

          <v-app-bar color="indigo" class="rounded-pill" dense dark>
            <v-avatar>
              <v-icon>fas fa-american-sign-language-interpreting</v-icon>
            </v-avatar>
            <v-toolbar-title>Popular</v-toolbar-title>
          </v-app-bar>

          <v-card class="mt-4">
            <v-card-subtitle><b>Today</b></v-card-subtitle>
            <v-divider></v-divider>
            <v-list class="py-0" v-for="(val, index) in chats" :key="index">
              <v-list-item link>
                <v-row>
                  <v-col cols="12" lg="2">
                    <v-avatar>
                      <v-img :src="val.src"></v-img>
                    </v-avatar>
                  </v-col>
                  <v-col cols="12" lg="10">
                    <v-card-title class="py-0">{{ val.header }}</v-card-title>
                    <v-card-text class="content py-1">
                      <b>{{ val.addressee }}</b> - {{ val.content }}
                    </v-card-text>
                  </v-col>
                </v-row>
              </v-list-item>
              <v-divider></v-divider>
            </v-list>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      pictures: [
        {
          src: "https://miro.medium.com/max/10944/1*Z7boPZktSNmP5P8uqDzqBQ.jpeg",
        },
        {
          src: "https://timviec365.com/pictures/images/coder-la-gi-2.jpg",
        },
        {
          src: "https://codersera.com/blog/wp-content/uploads/2019/07/photo-1518933165971-611dbc9c412d.jpg",
        },
        {
          src: "https://www.trilogyed.com/blog/wp-content/uploads/2019/07/MG_7947-1.jpg",
        },
      ],

      posts: [
        {
          src: "https://st.quantrimang.com/photos/image/2020/06/19/Hinh-Nen-Meo-Ngao-37.jpg",
          title: "Học viên mới bắt đầu khoá học",
          text:
            "Đây là lần đầu em theo học loại ngoại ngữ này. Cảm nhận của em là nó khá khó học, câu lệnh và cấu trúc thật là phức tạp. Tuy nhiên em nghe nói lương ngành này cao lắm nên em sẽ cố gắng theo học để tìm kiếm cơ hội đổi đời.",
        },
        {
          src: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQwvGORLHGG_JyeigNFBCxvGTVBe0m_c8mG2Q&usqp=CAU",
          title: 'Học viên sau khi code được "Hello World"',
          text: "Em không thể tin được là em có thể tạo ra được chương trình của riêng mình. Khi chương trình chạy em thấy nhiệt huyết tràn trề, code thật thú vị chứ không hề khó mọi người ạ.",
        },
        {
          src: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQkfZx4c0p9-O6wZBfMsVt4k6llP-kYKZ7ysw&usqp=CAU",
          title: 'Học viên sau khi dính "bug"',
          text: "lay troi code khong bug; lay troi code khong bug; lay troi code khong bug; lay troi code khong bug;",
        },
        {
          src:
            "data:image/jpeg;base64,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",
          title: "Học viên khi hoàn thành khoá học",
          text: "Em rất vui vì được tham gia khoá học đặc biệt này; em rất biết ơn mọi người đã giúp đỡ em trong suốt thời gian qua <3;",
        },
        {
          src:
            "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxISEhUQEhIQEBAQFQ8QDw8PDw8PDQ8QFRUWFhURFRUYHSggGBolGxUVITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OGhAQFy0dHR0tLSstLS0rLS0tLSstKy0tLS0tLS0tLS0tLS0tKystLS0tNy0rLS0tKystKzctLSsrLf/AABEIANAA8wMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAADAQIEBQYABwj/xAA0EAACAQIFAgUDAwQBBQAAAAAAAQIDEQQFEiExQVEGE2FxgSIykaGx8AcjM0LBUmLR4fH/xAAZAQADAQEBAAAAAAAAAAAAAAAAAQIDBAX/xAAhEQEBAAIDAQEAAgMAAAAAAAAAAQIREiExA0EiUQRhcf/aAAwDAQACEQMRAD8AyikJJg1IcjJrt1hriFsc4hsI7QlgziMZcoJGIRQEgSaS3v0W4qcJU+lKK937gPcJVeptgnE2nSaSw2o9ggKohoIIK/4kdcAaccKBEOFOAGtCxicx1JgZ1MLWV436r9hg9SK/NEjHHS22G3MlLTw7/mier4Tg8n8Of54nrGE4Q8VQatwUVbll5W4KOryzbFnfQZIFJBpApFkG4nDjhB59GIWEQ8KIVUTzssm8xBUDnEO6Y3yyZVaRnEZKBMdIG6TLmRcUVRDJ7C+WxZ9uxph3Ss0bYa7D2IomyQwVXkNJ/wD0jTluFTThBrkMuLZCfJ113BiBsC/JwIVMNgQ6kN1HRYbA9hRsBxZB149QRIlumvkBYjL04tPDS/vxPVsJweV+GF/eR6rhOBYrnglfgo6vLLvEcFJU5NsWV9CYOQSQORoRhxxwjZqnAK4oDCY91DyLHbLDZQGuA+51y5BuBaTtB05DfMHqjcNnG25ClMk4mpsQGzo+c1GOd7F1CTqA3yBqSL2jbqlS4y4jYtODb7iSfRoym7RV2aTKfBVastTahF+l2y58F5DrtOcWtDTV1Zs9IoUUlZJK3RE+quo83X9OO9WT+EJD+nV73qSXbg9HxdWMIuUmklu2+ECpYqEoKaaak0k+/QL/ANEv+nndX+m0rfTVd/8Auimv0KfMfA2LpbqMaqX/AESs/wAM9nk7Iizd9kUl8/1abi3GScZLlNWaGpmq8a4CXnNpc77bfjuZWSa5FKdmhIzCQncjoVMqUki4jpDFIkUncL2Is/DFNKrd9D0vCz2PNMllpmjf4StsGK/E+tLYpqnJPrVdisnI2xjKkYOTFlIFKRRFucDucAZFTF8wCIjz+MdKXGYrkBphWhKCqSG62LNDBybIPESAoWpLcadDK0ycgLY+cgcYt8CSdFGr8LZddqo4Qcb2vJp/Nu5UZVlvmyUW9N2lqte3wX+NwVTCTpqVWo8I5LzHT2lF9ePyTf6XJrttKGbQpPTNxSW2pNPT79UW2Bxqlz7ej9UeYVsqSVSdTFQq05JvD6Kl6kpPiUuyXUs/BWYz+2V5Ju2q97W2t6Idxyx9KZY5+LT+peaOFFU096j39k1sdgJTWVKpdudK1Rd/onqt+5A8Y5fPEVqcYq6jbU+2pqy/Q3OXZZGGGVG146XF363Qp2L0HhsxjVpRqwd1OKkvlGCzTxbUjVdO/lxu9U19U3Hiy6IusLSeEpVMO5fbqlSbum4vpt63MJi4eXVhUkuuppp2bXGzD05NNHUzOjWWhzcW+NU403L5k0zL59hIRl9D1dXvqaJ9TMMGpvEQhVnXlqtRnpdCE2mnLu1u3YkZVkahh51asbymrqOysuV8hljMPLsY5XP2aY4eifLKJuLmlsrlfboOVNlhyYahKzAXHU2US3y+a1L3RssJXMVl0d/k1+FHh6KsJ1CJKfIab2Ismboc5A5SFbByYGRyEGs4WwzKpjvLJVNDnE87k7+IEIDmggjYtlpHlEj4h2XuTZIr8Xu/Yv591H06iMxJS2OWwOW5u5i0qbk7G68KeH4SWqav6NFN4dyzXvY9DyShoWknfela1FFWwEaVVpKyla3Fk/YvHhI1KflySkmt01t+Bc4y1y+qDs16XIOX4ipCWmfD66WkiacqoqeC6aeznbq78e3cl4XJIUbRjfzJP6LOV5e67I1+Gw7l8knC5elN1Hu/tj6IrujciNluV2WqX3O179y3S2sOsIy5NM7dq3NcshWjZrdcSWzXszHVsqjNulONpU3q331xf+y/5PQWQsVg4yalb6o8P0fKFlirHLTDrIqUbtxW262i7A80r2pqC+rput0uiNJmuEkk9KuvTuUlHLZzeqd16W2sZ3e2ks0Zgsui6X1KzfKszA5xhtFSSXCZ6s4KMbcWRiM2wXmSlIfhSb6ZFDtaHV6LhKz2E0p+/wC5cZ1b5J9Xw1c1lBGN8OytUce6/Y2lIePp/glRkdsJVYBs6GZGxkmLJg5MRkucNOEajpVg+srYSDqoefcXbMh5TByqApTBOQSJuSR5hXSk7sl0ndkOtPouDb5467Z/TLYc5DaSuxr3LDKsG5zSXF+S2LdeEcK1BNmnjBp3I+UYTTBJdEixnB2JO3YtGd+STDDRe9l+CroSersW9GWw52V6GpwSVkESBoIhkRyG3I+KrqPqRljP5f8AnoXIE5s5lfRxup2v89CdGasBBSImLSSuS5Pch4zdE04osZWb+lb3/IyGX7fbz3RNo0lq4+S0dPYy1tpvTzDxRlNryStbf3MmnZnrWf0VKDT9TyvG0tMmVj0WXfabkcl5yeyupL3djaUnsecQlZ3/AAbzB17wi27txi2/WxX7svxJryI+oTEVdiP5yNecLiO5A5ME65Hq4gVzPiO6hxWvEnEcz4VXJBEFVMVUzl5HyCaBtEryhHSFMoe0CtKyt3IrYSvK7YG50zxFu6JSibHwrhd9TXsZXBrc9A8P0XZbcjga7BxsiWmAoRsg0ad+pNIydFc9STh3sDdJoZ5lggT0dOQKjUurnVp7FQaY3xbn6pt04u8lzuue3vv+hiZ+I613aTSf8v8AoQsyxb1y1XdRynqv0d9yvVVdiplVXUabAeJ6mpanJvuuT0rIcxVampJ7raS7OyPDlWs7rlHov9PcydWVTbTaNNSs9nK8rO3sXy3EWN1Wl1IuIldW6sfiqn0tre3HuQI1G+eTPI5EqnR0halTYFTpO3I7R0M1M9n1X6fyea5p9zv1PU86wt4Nd/3PK8zvqafKumUSAmaHKsd9GlveG3x0M8yRhKtn77ML4Mbqr6viyO8SRpDbGXJt0lPEA5ViO0Ix7HR7mcCscGws1AeqYsEFijjtc5qpg8VG0JPsmTIwT629xMXh7wkl1T/JMy7g2yM2IhZrcRHpmn5bG8l7o9PyaKSXxZdTy3AVLST9T0rIpakne5U8KtXQ3JSRDw7JcWLQ2Uj1odfySQU2TTNw76dtzsRUsu//AAQ6tfQ7/kbiMSmrp/ruGzeY+LctjGvKpeWio220t4Slvv3XJm5QS4ZsPFFWUpWi9afb6vT5MtUw9uWl6dSrDAUVfuegeAcG6cZSas6mnttFXsv1MTQwz5jaT6W3N74em4wSaaa7p/vbcJ0TU4mpaP7IZhKX+z5Iznr67Lj1JuGIyu6PInaQNQVtoh4qrYchImZ11pseWZ3/AJJe5uM8xTjFyR59jqupt9SqcQ5HQZwiES4oq8UxXAJl8f7a+QzpnHllq0+VQ3Aa4kt0xkqY5kfKouk4P5Zw+Q3VlCI9REg0ERx2p0dGAWERkWFiyLTkZDNqOirJdL3XsyIi48Sw/uJ94/sU56vyu8JSotF7novhTFXgm9jziLNR4VrvVZv6Vb+I2wKvUcPPqS4Mg4OV0iYlYKUPcgFSQST2I9SRCkPGO6sUle6ls2lbdF1WfRFZiY/qRkvBU4uhK/f+XuQHlcZPeHNt7I1FOjeK7r9UdHDojtpuKXCZVGO6jZ9+xNq4TTv+SfNWCSWpBexLo3LJXj7bFnSZV06birLgl0KmxeLPL+02pVKfH1iTXqGfzjFW6+qNNpkUOf47mBl6rLHN6ilK6+SqmFFNOOEETR5XH+1H5/cPJDcBG1OPsh8mednf5VfEzSNlEJcZJilHEFo4czi1cUiIVMFEKkZUTESI+LBodciwcVV4jh9MZdm1+TPmozezptP0t7mZPQ/xr/BGU1SxLPLMV5ckyrRKos6cfUvWPDWYa4p/juaFVLnmPhbMtL0Ppwb7DYtSWxWSUxz6AJvoHhG6uDlTMqpElQuQMVh2i60DJ077Cs2cy0rsFDaz5JMsP1Q6nh7Mk3sKQ7UCdG4kKewet6D4RDQ30DEdpXsPq0x0tkVIW0LF2sZLOZbPurmnxtVLkxefVt3G5ejjN1ndgKsLEyFO7AYrsLRVFH0ablJRXLaQ0tcjobub7WiRnlxx2MZurm1kl2SQOSHOQ1yPOkdOoa0CmEcgU2VImw3ScdcQokxSF1EbUdrJ4nal6xymRI1AsZE8S2gZ7W2UfkpCZmtW836bEM9D5Y8cZGWV3SpCptC00PRolJwGJtNX235R6fkldSirHktzZeD8yt9Dfr8FTvoq9Jw8tg7iQsHUTS/JJU9xWEXTuMcQje42YjMsNmjpSO6EmZKnwPSFEuPQJOPAytwwk5EKvW5HolHntay27GIx9XW79VsX/ifGWVlyzM05dSlw5y0K7XJVVZ3dyVj8RqduiITe4qVOhEvMJU+lW26FHBlhgattu5l9cd4q+d1Vjc5zGCNnHpr4c5DHIRsaypCvbtZwNs4rRcaLqOuckPhTuSNOgwttr9hYUh9b7X7Mn9VjjWaryu2xh1TlnHoOcWHAp0BUMGkjLsS6crojHSAPUfDua6lv2/BpKVTg858NYhON1zxJdmbHBYm/6FUqvmwdaQFVhZO5FENpSuFbGwjZHLchTtY2UjpqwkioRkqhSZnjlBO7LKrUsYzP9Um7N2vwUciom3iKrd3bexGxsNF12LTA0HT3ktpLZ9mUWbYjXNpcJ/lj/Ni1CuMQ8YSRyDQlbcCPixwLijWuh5XYOpZ2LJHH9MeOTXG2myGqI85ijaQNwOFZwwVSJNIh3Q6FWxllETLSeBrzSixqxBCx9ba3cPnjbku5yTaqqdREOYxHoOQeDFQNsIhg2aEY5jWgCbk2N8qor/bLaX/k9GwU+LHlTNt4NzXXHyZP64fbf/aP/ocFbKnJkqnIj0rWJVOkTSK6gkKn5CeWMdImnAp1Lg5zDKlwJOkOBBrq5V1MHdu5dygV2a4iNODnJ2UU2ypBtlfEmMVOGhfdL7fRdWY9EnMcY61R1H1+1do9ER0FDhiHtgxA9CxYhyACRdty3oO8blOWuXO8TL7zra/n6K4jJMKwbRzytraHdnCtHFF2/9k=",
          title: "Học viên ưu tú",
          text: "Hacking NASA...",
        },
      ],

      cards: [
        {
          src: "https://code.visualstudio.com/assets/docs/languages/csharp/c_sharp_hero.png",
          title: "Fullstack .NET Web Developer",
          subtitle: "Number 10",
          text: "<div>Whitehaven Beach</div><div>Whitsunday Island, Whitsunday Islands</div>",
        },
        {
          src: "https://miro.medium.com/max/2676/1*hhQv7Zxf213kHmZcQcuWmQ.png",
          title: "Fullstack Java Web Developer",
          subtitle: "Number 10",
          text: "<div>Whitehaven Beach</div><div>Whitsunday Island, Whitsunday Islands</div>",
        },
        {
          src: "https://dlwlrmax.github.io/mucsi/src/image/album/albumBG2.png",
          title: "Fresher Tester",
          subtitle: "Number 10",
          text: "<div>Whitehaven Beach</div><div>Whitsunday Island, Whitsunday Islands</div>",
        },
        {
          src: "https://toidicodedao.files.wordpress.com/2020/10/intern_collaboration2.jpg?w=672&h=372&crop=1",
          title: "Những việc nên làm khi mới gia nhập công ty, đi thực tập",
          subtitle: "Number 10",
          text: "<div>Whitehaven Beach</div><div>Whitsunday Island, Whitsunday Islands</div>",
        },
      ],

      links: [
        {
          icon: "fab fa-google-plus-g",
          color: "red",
        },
        {
          icon: "fab fa-facebook-f",
          color: "blue",
        },
        {
          icon: "fab fa-twitter",
          color: "blue lighten-2",
        },
      ],

      chats: [
        {
          src: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTfgl5OAd43myOHFpM1yG_d2X-SP1RfdTrJCw&usqp=CAU",
          header: "Shopping this weekend?",
          addressee: "Ali Connors",
          content:
            "I'll be in your neighborhood doing errands this weekend. Would you like to go shopping at 5pm? I'll be in your neighborhood doing errands this weekend. Would you like to go shopping at 5pm?",
        },
        {
          src: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTfgl5OAd43myOHFpM1yG_d2X-SP1RfdTrJCw&usqp=CAU",
          header: "Shopping this weekend?",
          addressee: "Ali Connors",
          content:
            "I'll be in your neighborhood doing errands this weekend. Would you like to go shopping at 5pm? I'll be in your neighborhood doing errands this weekend. Would you like to go shopping at 5pm?",
        },
        {
          src: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTfgl5OAd43myOHFpM1yG_d2X-SP1RfdTrJCw&usqp=CAU",
          header: "Shopping this weekend?",
          addressee: "Ali Connors",
          content: "I'll be in your neighborhood doing errands this weekend. Would you like to go shopping at 5pm?",
        },
        {
          src: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTfgl5OAd43myOHFpM1yG_d2X-SP1RfdTrJCw&usqp=CAU",
          header: "Shopping this weekend?",
          addressee: "Ali Connors",
          content: "I'll be in your neighborhood doing errands this weekend. Would you like to go shopping at 5pm?",
        },
      ],
    };
  },
};
</script>
<style>
.posts {
  position: relative;
}
.cardBtn {
  position: absolute;
  bottom: 10px;
  right: 20px;
}
/* Giới hạn dòng cho đoạn văn bản, nếu quá giới hạn sẽ hiển thị ... */
.content {
  display: -webkit-box;
  height: 16px * 1.3 * 3;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: pre-wrap;
}
.home {
  width: 90%;
  padding: 1% 2% !important;
  background-color: white;
  min-height: 800px;
}
#screen {
  padding-top: 1px;
  opacity: 1;
}
</style>
