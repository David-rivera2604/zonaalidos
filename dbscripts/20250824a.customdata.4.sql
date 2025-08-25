INSERT INTO CUSTOMDATA (ID,COMPANYID,ENTITYTYPE,ENTITYSUBTYPE,ENTITYID,"DATA",KEY1,KEY2,UPDATEUSERCODE,UPDATEDATE) VALUES (4,0,2000,0,1,TO_CLOB('class PlanTramitacionStream {
  constructor(containerId, json){
    this.el = document.getElementById(containerId);
    this.rows = (json && json.Plantramitacion) ? json.Plantramitacion.slice() : [];
    this.fmt  = new Intl.DateTimeFormat(''es-CR'',{year:''2-digit'',month:''2-digit'',day:''2-digit'',hour:''2-digit'',minute:''2-digit''});
  }

  render(){
    if(!this.el) return;
    const items = this.#prepare(this.rows);

    // Agrupar por Nivel → Trámite
    const byNivel = new Map();
    for(const it of items){
      const kNivel = it.codNivel || it.nivel;
      if(!byNivel.has(kNivel)) byNivel.set(kNivel,{cod:it.codNivel,nombre:it.nomNivel,tramites:new Map()});
      const nivel = byNivel.get(kNivel);
      const kTram = it.codTramite + ''::'' + it.nomTramite;
      if(!nivel.tramites.has(kTram)) nivel.tramites.set(kTram,{cod:it.codTramite,nombre:it.nomTramite,items:[]});
      nivel.tramites.get(kTram).items.push(it);
    }

    // Encabezado (Plan + #niveles)
    const header = document.getElementById(''headerTitle'');
    if(header) header.textContent = `${this.#planLabel(this.rows)} — ${byNivel.size} niveles`;

    // Render (Niveles abiertos, Trámites cerrados)
    let html = '''';
    let nivCount = 0;
    for(const nivel of Array.from(byNivel.values()).sort((a,b)=>String(a.cod).localeCompare(String(b.cod)))){
      const nid = `nivel_${++nivCount}`;
      const tramites = Array.from(nivel.tramites.values()).sort((a,b)=>String(a.cod).localeCompare(String(b.cod)));

      let tramHtml = '''';
      let tCount = 0;
      for(const tramite of tramites){
        const tid = `${nid}_tram_${++tCount}`;
        tramHtml += this.#renderTramiteBlock(tramite, tid, true); // trámites cerrados
      }

      html += `
        <div class="nivel-block">
          <div class="nivel-header" data-toggle="collapse" data-target="#${nid}">
            <span class="badge badge-secondary">Nivel ${this.#esc(nivel.cod||'''')}</span>
            <strong>${t')||TO_CLOB('his.#esc(nivel.nombre||''(Sin nombre)'')}</strong>
            <span class="count">${tramites.length} ${this.#tramLabel(tramites.length)}</span>
          </div>
          <div id="${nid}" class="collapse show">${tramHtml}</div>
        </div>`;
    }

    this.el.innerHTML = html || ''<p class="text-muted mb-0">Sin actividades registradas.</p>'';
  }

  #renderTramiteBlock(tramite, id, open){
    const n = tramite.items.length;
    return `
      <div class="tramite-block">
        <div class="tramite-header" data-toggle="collapse" data-target="#${id}">
          <span class="tag">Trámite ${this.#esc(tramite.cod||'''')}</span>
          <strong>${this.#esc(tramite.nombre||''(Trámite)'')}</strong>
          <span class="count">${n} ${this.#obsLabel(n)}</span>
        </div>
        <div id="${id}" class="collapse${open?'' show'':''''}">
          <div class="activity-stream">
            ${tramite.items.map(it=>this.#renderItem(it)).join('''')}
          </div>
        </div>
      </div>`;
  }

  #renderItem(it){
    const when = it.fecha ? this.fmt.format(it.fecha) : '''';
    return `
      <div class="stream">
        <div class="stream-badge"><i class="fa ${it.icon} ${it.color}"></i></div>
        <div class="stream-panel">
          <div class="obs-text">${this.#esc(it.texto)}</div>
          <div class="meta-line">
            <span class="who">${this.#esc(it.usuario)}</span>
            <span class="date">${this.#esc(when)}</span>
          </div>
        </div>
      </div>`;
  }

  // --- helpers ---
  #prepare(rows){
    const out=[]; const seen=new Set();
    for(const r of rows){
      const key = JSON.stringify([r.COD_NIVEL,r.COD_TRAMITE,r.NUM_SECU,r.OBS_TRAMITE,r.COD_USR,r.FEC_ACTU]);
      if(seen.has(key)) continue; seen.add(key);
      const fechaISO = r.FEC_ACTU || r.FEC_INICIO || null;
      out.push({
        codNivel: r.COD_NIVEL,
        nomNivel: r.NOM_NIVEL,
        codTramite: r.COD_TRAMITE,
        nomT')||TO_CLOB('ramite: r.NOM_TRAMITE,
        usuario: r.COD_USR || '''',
        texto: r.OBS_TRAMITE || '''',
        fecha: fechaISO ? new Date(fechaISO) : null,
        icon: this.#pickIcon(r),
        color: this.#pickColor(r)
      });
    }
    out.sort((a,b)=>(b.fecha?.getTime()||0)-(a.fecha?.getTime()||0));
    return out;
  }
  #planLabel(rows){
    if(!rows || !rows.length) return ''Plan de tramitación'';
    const r0 = rows[0];
    if(r0.NOM_PLAN) return r0.NOM_PLAN;
    if(r0.COD_PLAN) return `Plan ${r0.COD_PLAN}`;
    return ''Plan de tramitación'';
  }
  #pickIcon(r){
    const t=(r.OBS_TRAMITE||'''').toLowerCase();
    if(t.includes(''aviso'')) return ''fa-envelope'';
    if(t.includes(''banco'')) return ''fa-bank'';
    if(t.includes(''agenda'')) return ''fa-calendar'';
    return ''fa-check'';
  }
  #pickColor(r){
    const e=(r.NOM_TIP_EST_TRAMITE||'''').toLowerCase();
    if(e.includes(''pend'')) return ''bg-warning'';
    if(e.includes(''iniciado'')||e.includes(''activo'')) return ''bg-success'';
    if(e.includes(''final'')||e.includes(''complet'')||e.includes(''cerr'')) return ''bg-primary'';
    return '''';
  }
  #tramLabel(n){return n===1? ''trámite'' : ''trámites''}
  #obsLabel(n){return n===1? ''observación'' : ''observaciones''}
  #esc(s){return String(s||'''').replace(/&/g,''&amp;'').replace(/</g,''&lt;'').replace(/>/g,''&gt;'').replace(/\"/g,''&quot;'').replace(/''/g,''&#39;'');}
}

app.ui.ShowSideBar({ title: ''Plan de tramitación'', subtitle: ''Información'', isHTML: true, HTML: `<div id="plan-container"></div>`, data: null, width: ''360px'' });
app.core.datapi(''GET'', `siniestro/${context}?include=plantramitacion`)
    .then(data => {
		if (data !== null) {
			new PlanTramitacionStream(''plan-container'', data).render();
        }
    });
'),'PlanTramitacion','Render',6329,TIMESTAMP'2025-07-23 19:15:09');
